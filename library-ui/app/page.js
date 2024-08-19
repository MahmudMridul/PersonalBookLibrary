"use client";

import { useState, useRef, useEffect } from 'react';
import Layout from './components/Layout';
import LoginForm from './components/LoginForm';
import RegisterForm from './components/RegisterForm';

export default function Home() {
   const [isLoginVisible, setIsLoginVisible] = useState(true);
   const [contentHeight, setContentHeight] = useState('auto');
   const contentRef = useRef(null);

   useEffect(() => {
      if (contentRef.current) {
         setContentHeight(`${contentRef.current.scrollHeight + 48}px`);
      }
   }, [isLoginVisible]);

   const handleSignUp = () => {
      setIsLoginVisible(false);
   };
   const handleSignIn = () => {
      setIsLoginVisible(true);
   };

   return (
      <Layout>
         <div
            className="bg-white shadow-md rounded-xl p-6 overflow-hidden transition-all duration-500 ease-in-out"
            style={{ height: contentHeight }}
         >
            <div ref={contentRef}>
               {isLoginVisible ? (
                  <LoginForm onSignUp={handleSignUp} />
               ) : (
                  <RegisterForm onSignIn={handleSignIn} />
               )}
            </div>
         </div>
      </Layout>
   );
}