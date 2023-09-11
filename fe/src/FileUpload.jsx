import React, { useState, useEffect } from 'react';
import { useDropzone } from 'react-dropzone';
import { json } from 'react-router-dom';

function FileUpload() {
    const [files, setFiles] = useState([]);
    const [documentList, setDocumentList] = useState([]);
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");

    const onDrop = (acceptedFiles) => {
        setFiles(acceptedFiles);
    };

    const { getRootProps, getInputProps } = useDropzone({ onDrop });

function getId(){
    var usr = JSON.parse(localStorage.getItem('token'));
  //  usr = JSON.parse(usr);
   

 
    return usr.id;
}
   

const handleSubmit = async (e) => {
    e.preventDefault();

    const formData = new FormData();

    for (const file of files) {
        formData.append('files', file); // Dosyaları ekleyin (birden fazla dosya için döngü kullanabilirsiniz)
    }

    formData.append('title', title);
    formData.append('description', description);
    formData.append('userID', getId());

    console.log(formData);

    try {
        const response = await fetch('https://localhost:7289/api/Document', {
            method: 'POST',
            body: formData,
        });

        if (response.ok) {
        
      
            setTitle("");
            setDescription("");
            setFiles([]);
        } else {
            console.error('API isteği başarısız oldu');
        }
    } catch (error) {
        console.error('API isteği sırasında bir hata oluştu', error);
    }
};

    
    
    

    // Geri kalan bileşen render işlemleri burada

    return (
        <div>
            {/* ... */}
            <h2>Dosya Yükleme</h2>
            <form onSubmit={handleSubmit}>
                <div {...getRootProps()} style={dropzoneStyle}>
                    <input {...getInputProps()} />
                    <p>Dosyalarınızı buraya sürükleyin veya tıklayın</p>
                </div>
                <input
                    type="text"
                    placeholder="Başlık"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Açıklama"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />
                <button type="submit">Yükle</button>
            </form>
            {/* ... */}
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
