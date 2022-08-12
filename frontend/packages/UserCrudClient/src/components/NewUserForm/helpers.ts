import { UserDataModel } from "../UserIndex/helpers";

export type UserFormControlData = Omit<UserDataModel, 'id' | 'dateCreated'>;
