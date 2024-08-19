import React, { useState, useMemo, useCallback } from "react";
import { Input } from "@nextui-org/react";
import { Button } from '@nextui-org/button';

export default function RegisterForm({ onSignIn }) {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const validateName = (value) => value.length >= 3;
  const validateEmail = (value) => value.match(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i);
  const validatePassword = (value) => value.length >= 4;
  const validateConfirmPassword = useCallback((value) => value === password, [password]);

  const isNameInvalid = useMemo(() => {
    if (name === "") return false;
    return !validateName(name);
  }, [name]);

  const isEmailInvalid = useMemo(() => {
    if (email === "") return false;
    return !validateEmail(email);
  }, [email]);

  const isPasswordInvalid = useMemo(() => {
    if (password === "") return false;
    return !validatePassword(password);
  }, [password]);

  const isConfirmPasswordInvalid = useMemo(() => {
    if (confirmPassword === "") return false;
    return !validateConfirmPassword(confirmPassword);
  }, [confirmPassword, validateConfirmPassword]);

  const isFormValid = useMemo(() => {
    return (
      name !== "" &&
      email !== "" &&
      password !== "" &&
      confirmPassword !== "" &&
      !isNameInvalid &&
      !isEmailInvalid &&
      !isPasswordInvalid &&
      !isConfirmPasswordInvalid
    );
  }, [name, email, password, confirmPassword, isNameInvalid, isEmailInvalid, isPasswordInvalid, isConfirmPasswordInvalid]);

  const handleSignIn = () => {
    onSignIn()
  }

  const handleSubmit = (e) => {
    e.preventDefault();
    if (isFormValid) {
      console.log('Form Data:', {
        name,
        email,
        password,
        confirmPassword
      });
    }
  };

  return (
    <form className='pb-5' onSubmit={handleSubmit}>
      <h1 className="text-2xl font-bold text-center mb-4">
        Sign Up
      </h1>
      <div className="mb-4">
        <Input
          isRequired
          type="text"
          label="Name"
          value={name}
          onValueChange={setName}
          isInvalid={isNameInvalid}
          color={isNameInvalid ? "danger" : ""}
          className="w-full"
        />
      </div>
      <div className="mb-4">
        <Input
          isRequired
          type="email"
          label="Email"
          value={email}
          onValueChange={setEmail}
          isInvalid={isEmailInvalid}
          color={isEmailInvalid ? "danger" : ""}
          className="w-full"
        />
      </div>
      <div className="mb-4">
        <Input
          isRequired
          type="password"
          label="Password"
          value={password}
          onValueChange={setPassword}
          isInvalid={isPasswordInvalid}
          color={isPasswordInvalid ? "danger" : ""}
          className="w-full"
        />
      </div>
      <div className="mb-6">
        <Input
          isRequired
          type="password"
          label="Confirm Password"
          value={confirmPassword}
          onValueChange={setConfirmPassword}
          isInvalid={isConfirmPasswordInvalid}
          color={isConfirmPasswordInvalid ? "danger" : ""}
          errorMessage={isConfirmPasswordInvalid && "Passwords do not match"}
          className="w-full"
        />
      </div>
      <Button
        variant="ghost"
        type='submit'
        color="primary"
        radius="full"
        className='w-full'
        isDisabled={!isFormValid}
      >
        Sign Up
      </Button>
      <div className='w-full flex flex-row gap-1 mt-2'>
        <p className='text-medium'>Already have an account?</p>
        <span className='text-[#006fee] font-semibold text-medium cursor-pointer' onClick={handleSignIn}>Sign In</span>
      </div>
    </form>
  );
}