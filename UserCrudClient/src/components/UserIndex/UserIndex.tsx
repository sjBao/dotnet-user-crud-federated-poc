import React, { useEffect, useState, useRef } from 'react';

import { UserDataModel, fetchUsers } from './helpers';
import { NewUserForm } from '../NewUserForm';
import { Button } from '../Button';
import { ListItem } from '../ListItem';
import { Label } from '../Label';

import './UserList.css';
import './UserListItem.css';
import { Input } from '../Input';

type UserListProps = {
    users: UserDataModel[];
    deleteUser(userId: string): Promise<void>;
    editUser(userId: string, payload: any): Promise<void>;
}

const UserList = ({ users, deleteUser, editUser }: UserListProps) => {
    return (
        <div className="users-list-container">
            Users Index

            <ul className="users-list-container__list">
                {
                    users.map(user => (
                        <UserListItem
                            key={user.id}
                            user={user}
                            deleteUser={deleteUser}
                            editUser={editUser}
                        />
                    ))
                }
            </ul>
        </div>
    )
}

type UserListItemProps = {
    user: UserDataModel;
    editUser(userId: string, payload: any): void;
    deleteUser(userId: string): Promise<void>;
}

const UserListItem = ({ user, deleteUser, editUser }: UserListItemProps) => {
    const [isEditing, setIsEditing] = useState(false);
    const userNameRef = useRef<HTMLInputElement>(null);
    const firstNameRef = useRef<HTMLInputElement>(null);
    const lastNameRef = useRef<HTMLInputElement>(null);

    useEffect(() => {
        if (userNameRef.current) userNameRef.current.value = user.username;
        if (firstNameRef.current) firstNameRef.current.value = user.firstName;
        if (lastNameRef.current) lastNameRef.current.value = user.lastName;
    }, [isEditing]);

    const handleDeleteButtonClick = async () => {
        const { id: userId } = user
        try {
            deleteUser(userId);
        } catch (error) {
            console.log(error);
        }
    }

    const handleEditButtonClick = () => {
        setIsEditing(true);
    }

    const handleCanelButtonClick = () => {
        setIsEditing(false);
    }

    const handleUpdateUserButtonClick = async () => {
        const { id: userId } = user
        const username = userNameRef?.current?.value;
        const firstName = firstNameRef?.current?.value;
        const lastName = lastNameRef?.current?.value;

        try {
            editUser(userId, { username, firstName, lastName });

            setIsEditing(false);
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <ListItem className="users-list-item">
            <div className="users-list-item__username">
                <Label>Username</Label>
                {
                    isEditing ? (
                        <Input ref={userNameRef} name="username" />
                    ) : (
                        <div>
                            {user.username}
                        </div>
                    )

                }
            </div>
            <div className="users-list-item__first-name">
                <Label>First Name</Label>
                {
                    isEditing ? (
                        <Input ref={firstNameRef} name="firstName" />
                    ) : (
                        <div>
                            {user.firstName}
                        </div>
                    )

                }
            </div>
            <div className="users-list-item__last-name">
                <Label>Last Name</Label>
                {
                    isEditing ? (
                        <Input ref={lastNameRef} name="lastName" />
                    ) : (
                        <div>
                            {user.lastName}
                        </div>

                    )
                }
            </div>
            <div className="users-list-item__date-created">
                <Label>Date Created</Label>
                <pre>
                    {new Date(user.dateCreated).toLocaleString()}
                </pre>
            </div>
            {
                !isEditing ? (
                    <div className="users-list-item__menu">
                        <Button
                            secondary
                            className="users-list-item__edit-button"
                            onClick={handleEditButtonClick}
                        >
                            Edit
                        </Button>
                        <Button
                            className="users-list-item__delete-button"
                            onClick={handleDeleteButtonClick}
                            secondary
                        >
                            Delete
                        </Button>
                    </div>
                ) : (
                    <div className="users-list-item__menu">
                        <Button
                            primary
                            className="users-list-item__edit-button"
                            onClick={handleUpdateUserButtonClick}
                        >
                            Update User
                        </Button>
                        <Button
                            className="users-list-item__delete-button"
                            onClick={handleCanelButtonClick}
                            secondary
                        >
                            Cancel
                        </Button>
                    </div>
                )
            }

        </ListItem>
    );
}


export const UserIndex = () => {
    const [users, setUsers] = useState<UserDataModel[]>([]);

    const fetchAndSetUsers = async () => {
        const users = await fetchUsers();
        setUsers(users);
    }

    const addUser = async (user: Omit<UserDataModel, "id" | "dateCreated">) => {
        try {
            const response = await fetch('https://localhost:7236/users', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
            const newUser = await response.json();
            setUsers([...users, newUser]);
        } catch (error) {
            console.log(error);
        }
    }

    const editUser = async (userId: string, payload: any) => {
        const response = await fetch(`https://localhost:7236/users/${userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        });
        const updatedUser = await response.json();
        setUsers(users.map(user => user.id === updatedUser.id ? updatedUser : user));
    }

    const deleteUser = async (userId: string) => {
        try {
            const response = await fetch(`https://localhost:7236/users/${userId}`, {
                method: 'DELETE'
            });
            const user = await response.json();
            setUsers(users.filter(u => u.id !== user.id));
        } catch (error) {
            console.log(error);
        }
    }

    useEffect(() => {
        fetchAndSetUsers();
    }, []);

    return (
        <div className="container">
            <UserList editUser={editUser} deleteUser={deleteUser} users={users} />
            <NewUserForm addUser={addUser} />
        </div>
    );
}
