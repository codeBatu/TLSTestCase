import React, { useState, useEffect } from 'react';

function FileList() {
    const [documentList, setDocumentList] = useState([]);

    function getId() {
        // localStorage'tan alırken geri dönüştürmemiz gerekecek
        var usr = JSON.parse(localStorage.getItem('token'));
        return usr.id;
    }

    useEffect(() => {
        // İlk yüklemede döküman listesini çek
        fetchDocumentList();
    }, []);

    const fetchDocumentList = async () => {
        try {
            const response = await fetch('https://localhost:7289/api/Document/getAllById?id=' + getId());
            if (response.ok) {
                const data = await response.json();
                setDocumentList(data);
            } else {
                console.error('API isteği başarısız oldu');
            }
        } catch (error) {
            console.error('API isteği sırasında bir hata oluştu', error);
        }
    };

    const handlePrint = (document) => {
        console.log(document);
        if (document.fileType === 'pdf') {
            // PDF ise yeni sekmede aç
            window.open(document.url, '_blank');
        } else if (document.fileType === 'xlsx') {
            // Excel dosyasını indirme işlemi
            fetch(document.url, {
                method: 'GET',
            })
                .then((response) => response.blob())
                .then((blob) => {
                    const url = window.URL.createObjectURL(new Blob([blob]));
                    const a = document.createElement('a');
                    a.style.display = 'none';
                    a.href = url;
                    a.download = `${document.fileName}.${document.type}`;
                    document.body.appendChild(a);
                    a.click();
                    window.URL.revokeObjectURL(url);
                })
                .catch((error) => {
                    console.error('Dosya indirme işlemi sırasında hata oluştu', error);
                });
        }
    };

    return (
        <div>
            <h2>Döküman Listesi</h2>
            <ul>
                {documentList.map((document) => (
                    <li key={document.id}>
                        {document.fileName} ({document.filePath}) ({document.filePath})
                        <button onClick={() => handlePrint(document)}>Yazdir</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default FileList;
