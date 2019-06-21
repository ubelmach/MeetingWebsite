import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class ChatService {

    constructor(private fb: FormBuilder,
        private http: HttpClient) { }

    readonly BaseURI = 'https://localhost:44333/api';

    getUserDialogs() {
        return this.http.get(this.BaseURI + '/dialog/GetAllDialogs');
    }

    getDetailsUserDialogs(id: number){
        return this.http.get(this.BaseURI + '/dialog/DialogDetails/' + id)
    }
}