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

    const handleSubmit = (event) => {
        event.preventDefault();
        // Burada gerçek bir kimlik doğrulama işlemi yapabilirsiniz.
        console.log('Kullanıcı Adı:', username);
        console.log('Şifre:', password);
        window.location.href = '/FileUpload';
      //  history.push();
    };

    return (
        <div>
            <h2>Kullanıcı Girişi</h2>
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
