import React, { useState } from 'react';

function LoginScreen() {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleUsernameChange = (event) => {
        setUsername(event.target.value);
    };

    const handlePasswordChange = (event) => {
        setPassword(event.target.value);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        const data = {
            userName: username,
            password: password
        };

        try {
            const response = await fetch('https://localhost:7289/api/Account/user/authenticate', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });

            if (response.ok) {
                const result = await response.json();
                console.log('API Response:', result);

                // Başarılı ise local storage'a kaydet
                // Başarılı ise local storage'a kaydet
                localStorage.setItem('token', JSON.stringify(result));

                // localStorage'tan alırken geri dönüştürmemiz gerekecek
                var usr = JSON.parse(localStorage.getItem('token'));

                // Alınan veriyi kullanabilirsiniz
                console.log(usr.id);
                // Yönlendirme
                <h1>Hoşgeldiniz {usr.id}</h1>
               window.location.href = '/FileUpload';
             
            } else {
                console.error('API Error:', response.statusText);
            }
        } catch (error) {
            console.error('API Error:', error);
        }
    };


    return (
        <div>
            <h2>Kullanıcı Girişi  </h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="username">Kullanıcı Adı:</label>
                    <input
                        type="text"
                        id="username"
                        value={username}
                        onChange={handleUsernameChange}
                    />
                </div>
                <div>
                    <label htmlFor="password">Şifre:</label>
                    <input
                        type="password"
                        id="password"
                        value={password}
                        onChange={handlePasswordChange}
                    />
                </div>
                <div>
                    <button type="submit">Giriş Yap</button>
                </div>
            </form>
        </div>
    );
}

export default LoginScreen;
