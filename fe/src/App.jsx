import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import LoginPage from './LoginPage'
import FileUpload from './FileUpload'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
          <LoginPage />
   <FileUpload />
    </>
  )
}

export default App
