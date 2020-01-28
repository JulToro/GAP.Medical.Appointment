import { UUID } from 'angular2-uuid';
export interface PatientModel {
    id?: UUID;
    documentId: string;
    name: string;
    lastName: string;
    phoneNumber: string;
    email: string;
    userName?: string;    
    password?: string;
}
