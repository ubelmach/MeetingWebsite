import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class BlackListService {
    constructor(private fb: FormBuilder, private http: HttpClient) { }
    readonly BaseURI = 'https://localhost:44333/api';

    getBlackList(){
        return this.http.get(this.BaseURI + '/blacklist/BlackList');
    }

    AddToBlackList(userId: string){
        return this.http.get(this.BaseURI + '/blacklist/AddUserInBlackList/' + userId);
    }

    DeleteFromBlacklist(id: number){
        return this.http.get(this.BaseURI +'/blacklist/DeleteUserFromBlackList/' + id.toString());
    }

    CheckBlacklist(id: string){
        return this.http.get(this.BaseURI + '/friend/checkBlacklist/' + id.toString());
    }

    CheckBlackListFromProfile(id: string){
        return this.http.get(this.BaseURI + '/blacklist/CheckBlacklist/' + id);
    }

    DeleteBlackListFromUserProfile(id: string){
        return this.http.get(this.BaseURI + '/blacklist/DeleteFromUserProfile/' + id);
    }

}