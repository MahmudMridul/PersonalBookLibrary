import { Button } from '@nextui-org/button';
import { Input } from "@nextui-org/react";
import { EyeFilledIcon } from "../assets/icons/EyeFilledIcon";
import { EyeSlashFilledIcon } from "../assets/icons/EyeSlashFilledIcon";
import React from "react";
import Link from 'next/link';

export default function LoginForm({ onSignUp }) {
  const [email, setEmail] = React.useState("");
  const [password, setPassword] = React.useState("");
  const [isVisible, setIsVisible] = React.useState(false);

  const validateEmail = (value) => value.match(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i);

  const isInvalid = React.useMemo(() => {
    if (email === "") return false;

    return validateEmail(email) ? false : true;
  }, [email]);

  const toggleVisibility = () => setIsVisible(!isVisible);

  const handleSigUp = () => {
    onSignUp();
  }

  return (
    <form className='pb-5'>
      <h1 className="text-2xl font-bold text-center mb-4">
        Sign In
      </h1>
      <div className="mb-4">
        <Input
          value={email}
          type="email"
          label="Email"
          isInvalid={isInvalid}
          color={isInvalid ? "danger" : ""}
          errorMessage="Please enter a valid email"
          onValueChange={setEmail}
          className="w-full"
        />
      </div>
      <div className="mb-6">
        <Input
          label="Password"
          onValueChange={setPassword}
          endContent={
            <button className="focus:outline-none" type="button" onClick={toggleVisibility} aria-label="toggle password visibility">
              {isVisible ? (
                <EyeSlashFilledIcon className="text-2xl text-default-400 pointer-events-none" />
              ) : (
                <EyeFilledIcon className="text-2xl text-default-400 pointer-events-none" />
              )}
            </button>
          }
          type={isVisible ? "text" : "password"}
          className="w-full"
        />
      </div>
      <div className="flex items-center justify-between">
        <Button type='submit' color="primary" radius="full" className='w-full'>Sign In</Button>
      </div>
      <div className='w-full flex flex-row gap-1 mt-2'>
        <p className='text-medium'>Don&apos;t have an account?</p>
        <span className='text-[#006fee] font-semibold text-medium cursor-pointer' onClick={handleSigUp}>Sign Up</span>
      </div>
    </form>
  );
}
