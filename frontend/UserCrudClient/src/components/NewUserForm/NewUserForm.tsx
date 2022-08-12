import React, { useRef } from 'react';

import { UserFormControlData } from './helpers';
import { Input } from '../Input';
import { Label } from '../Label';
import { Button } from '../Button';

interface NewUserFormElement extends HTMLFormElement {
    username: HTMLInputElement;
    firstName: HTMLInputElement;
    lastName: HTMLInputElement;
}

type NewUserFormProps = {
    addUser(user: UserFormControlData): void;
}

export const NewUserForm = ({ addUser }: NewUserFormProps) => {
    const handleFormSubmit = (e: React.FormEvent<NewUserFormElement>) => {
        e.preventDefault();

        const { username, firstName, lastName } = formRef.current;
        addUser({
            username: username.value,
            firstName: firstName.value,
            lastName: lastName.value,
        });
    }

    const formRef = useRef<NewUserFormElement>({} as NewUserFormElement);

    return (
        <div className="new-user-form-container">
            <form ref={formRef} onSubmit={handleFormSubmit} className="user-form">
                <div className="user-form__input-container">
                    <Label htmlFor="username" className="user-form__label">
                        Username
                    </Label>
                    <Input type="text" id="username" name="username" className="user-form__input" />
                </div>
                <div className="user-form__input-container">
                    <Label htmlFor="firstName" className="user-form__label">
                        First Name
                    </Label>
                    <Input type="text" id="firstName" name="firstName" className="user-form__input" />
                </div>
                <div className="user-form__input-container">
                    <Label htmlFor="lastName" className="user-form__label">
                        Last Name
                    </Label>
                    <Input type="text" id="lastName" name="lastName" className="user-form__input" />
                </div>
                <div className="user-form__button-container">
                    <Button 
                        primary
                        type="submit" 
                        className="user-form__button"
                    >
                        Create User
                    </Button>
                </div>
            </form>
        </div>
    )
}
