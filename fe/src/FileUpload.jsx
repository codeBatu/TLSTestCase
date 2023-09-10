import React, { useState, useEffect } from 'react';
import { useDropzone } from 'react-dropzone';

function FileUpload() {
    const [files, setFiles] = useState([]);
    const [documentList, setDocumentList] = useState([]);

    const onDrop = (acceptedFiles) => {
        setFiles(acceptedFiles);
    };

    const { getRootProps, getInputProps } = useDropzone({ onDrop });

    useEffect(() => {
        // İlk yüklemede döküman listesini çek
        fetchDocumentList();
    }, []);

    const fetchDocumentList = async () => {
        try {
            const response = await fetch('https://localhost:7289/api/documente');
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
        if (document.type === 'pdf') {
            // PDF ise yeni sekmede aç
            window.open(document.url, '_blank');
        } else if (document.type === 'excel') {
            // Excel ise dosyayı indir
            window.location.href = document.url;
        }
    };

    return (
        <div>
            <h2>Dosya Yükleme</h2>
            <div {...getRootProps()} style={dropzoneStyle}>
                <input {...getInputProps()} />
                <p>Dosyalarınızı buraya sürükleyin veya tıklayın</p>
            </div>
            <h2>Döküman Listesi</h2>
            <button onClick={fetchDocumentList}>Listeyi Güncelle</button>
            <ul>
                {documentList.map((document) => (
                    <li key={document.id}>
                        {document.name} ({document.type})
                        <button onClick={() => handlePrint(document)}>Yazdır</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}

const dropzoneStyle = {
    border: '2px dashed #cccccc',
    borderRadius: '4px',
    padding: '20px',
    textAlign: 'center',
    cursor: 'pointer',
};

export default FileUpload;
