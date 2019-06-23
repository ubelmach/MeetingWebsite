import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { Lightbox } from 'ngx-lightbox';
import { AlbumService } from 'src/app/shared/album.service';

@Component({
  selector: 'app-user-profile-details-album',
  templateUrl: './user-profile-details-album.component.html',
  styleUrls: ['./user-profile-details-album.component.css']
})
export class UserProfileDetailsAlbumComponent implements OnInit {

  photos = new Array();
  idAlbum: number;
  private _album = new Array();
  baseUrl = 'https://localhost:44333';

  constructor(private activateRoute: ActivatedRoute,
    public service: AlbumService,
    private router: Router,
    private _lightbox: Lightbox) {  }

  async ngOnInit() {
    await this.activateRoute.params.subscribe(
      params => this.idAlbum = params.id
    );

    this.service.OpenAlbum(this.idAlbum).subscribe(
      (res: any) => {
        this.photos = res;
        this.photos.forEach(photo => {
          const src = this.baseUrl + photo.PathPhoto;
          const caption = '';
          const thumb = '';
          const album = {
            src: src,
            caption: caption,
            thumb: thumb
          };
    
          this._album.push(album);
        });
        
        console.log('open')
      },
      err => {
        console.log(err);
      }
    )
  }

  open(index: number): void {
    this._lightbox.open(this._album, index);
    console.log('open image' + index);
  }

  close() : void{
    this._lightbox.close();
  }

}
