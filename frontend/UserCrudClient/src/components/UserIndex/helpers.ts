export type UserDataModel = {
    id: string;
    username: string;
    firstName: string;
    lastName: string;
    dateCreated: string;
}

export const fetchUsers = async (): Promise<UserDataModel[]> => {
    const response = await fetch('https://localhost:7236/users');
    const users = await response.json();
    return users;
}
