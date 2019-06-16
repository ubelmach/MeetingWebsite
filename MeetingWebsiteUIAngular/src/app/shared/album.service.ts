import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class AlbumService {

    constructor(private fb: FormBuilder,
        private http: HttpClient) { }

    readonly BaseURI = 'https://localhost:44333/api';

    formModel = this.fb.group({
        Name: ['', Validators.required]
    })

    getAlbums(){
        return this.http.get(this.BaseURI + '/album/GetAllAlbum');
    }
    
    createAlbum() {
        var body = {
            Name: this.formModel.value.Name
        }
        return this.http.post(this.BaseURI + '/album/CreateAlbum', body);
    }

    OpenAlbum(id: number){
        return this.http.get(this.BaseURI  + '/album/AlbumDetails/' + id.toString());
    }

}