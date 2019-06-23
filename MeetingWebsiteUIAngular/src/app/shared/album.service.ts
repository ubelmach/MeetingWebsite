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

    getAlbumsUser(id: string){
        return this.http.get(this.BaseURI + '/album/GetAllAlbumUser/' + id);
    }
    
    createAlbum() {
        var body = {
            Name: this.formModel.value.Name
        }
        return this.http.post(this.BaseURI + '/album/CreateAlbum', body);
    }

    OpenAlbum(id: number){
        return this.http.get(this.BaseURI  + '/album/AlbumDetails/' + id);
    }

    DeleteAlbum(id: number){
        return this.http.delete(this.BaseURI + '/album/DeleteAlbum/' + id)
    }

    DeletePhoto(id: number){
        return this.http.delete(this.BaseURI + '/album/DeletePhotoInAlbum/' + id);
    }
    
    AddPhoto(id: number, fileToUpload: File){
        const formData: FormData = new FormData();
        formData.append('Image', fileToUpload);
        return this.http.put(this.BaseURI + '/album/AddPhotoInAlbum/' + id, formData);
    }
}