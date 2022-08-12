
import React, { forwardRef } from 'react';

import './Input.css';

export type InputRef = HTMLInputElement;
export interface InputProps {
    className?: string;
    name?: string;
    id?: string;
    onChange?: (e: React.ChangeEvent<InputRef>) => void;
    onBlur?: (e: React.FocusEvent<InputRef>) => void;
    onFocus?: (e: React.FocusEvent<InputRef>) => void;
    value?: string;
    type?: "text" | "password" | "email" | "number" | "tel" | "search" | "url" | "date" | "datetime-local" | "time" | "week";
}

const _CLASS_NAME = 'user-crud-client__input';
export const Input = forwardRef<InputRef, InputProps>(({
    id,
    name,
    className,
    onChange,
    onBlur,
    onFocus,
    type
}, ref) => {
    const renderedClassName = [_CLASS_NAME, className].join(' ');
    return (
        <input
            className={renderedClassName}
            id={id}
            ref={ref ? ref : null} 
            name={name}
            onChange={onChange}
            onBlur={onBlur}
            onFocus={onFocus}
            type={type || "text"}
        />
    )
});
