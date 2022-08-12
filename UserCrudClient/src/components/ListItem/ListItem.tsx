import React from 'react';

import './ListItem.css';

export interface ListItemProps {
    children: React.ReactNode;
    className?: string;
}

const _CLASS_NAME = 'user-crud-client__list-item';
export const ListItem = ({ children, className }: ListItemProps) => {
    const renderedClassName = [className, _CLASS_NAME].join(' ');
    return (
        <li className={renderedClassName}>
            {children}
        </li>
    )
}
