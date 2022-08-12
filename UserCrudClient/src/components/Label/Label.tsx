import React from 'react';

import './Label.css';

export interface LabelProps {
    htmlFor?: string;
    className?: string;
    children: React.ReactNode;
}

const _CLASS_NAME = 'user-crud-client__label';
export const Label = ({ children, className, ...rest }: LabelProps) => {
    const renderedClassName = [className, _CLASS_NAME].join(' ');
    return (
        <label
            {...rest}
            className={renderedClassName}
        >
            {children}
        </label>
    )
}
