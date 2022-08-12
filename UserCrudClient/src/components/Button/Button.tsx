import React from 'react';
import './Button.css';

interface ButtonProps {
    children: React.ReactNode;
    className?: string;
    onClick?(e?: React.MouseEvent<HTMLButtonElement>): void;
    primary?: boolean;
    secondary?: boolean;
    type?: 'button' | 'submit' | 'reset';
}

export const Button = ({ onClick, children, className, primary, secondary, type }: ButtonProps) => {
    const renderedClassName = [
        className,
        'user-crud-client__button',
        primary ? 'primary' : '',
        secondary ? 'secondary' : '',
    ].join(' ');

    return (
        <button className={renderedClassName} onClick={onClick} type={type}>
            { children }
        </button>
    )
}
