import { Component, OnInit } from '@angular/core';
import { AlbumService } from 'src/app/shared/album.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { Lightbox } from 'ngx-lightbox';


@Component({
  selector: 'app-details-album',
  templateUrl: './details-album.component.html',
  styleUrls: ['./details-album.component.css']
})
export class DetailsAlbumComponent implements OnInit {

  photos = new Array();
  idAlbum: number;
  private _album = new Array();
  baseUrl = 'https://localhost:44333';

  constructor(private activateRoute: ActivatedRoute,
    public service: AlbumService,
    private router: Router,
    private toastr: ToastrService,
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

  onDeleteAlbum() {
    this.service.DeleteAlbum(this.idAlbum).subscribe(
      (res: any) => {
        this.toastr.success('Delete album');
        this.router.navigateByUrl('home/album');
        console.log('delete album');
      },
      (err: any) => {
        if (err.status == 400)
          this.toastr.error('Faild delete album');
        else
          console.log(err);
      }
    )
  }

  onDeletePhoto(id: number) {
    this.service.DeletePhoto(id).subscribe(
      (res: any) => {
        this.toastr.success('Delete photo');
        this.ngOnInit();
        console.log('delete photo');
      },
      (err: any) => {
        if (err.status == 400)
          this.toastr.error('Faild delete photo');
        else
          console.log(err);
      }
    )
  }

  fileToUpload: File[] = new Array();

  onFilesAdded(files: File[]) {   
    this.fileToUpload = files;
    files.forEach(file => {
      const reader = new FileReader();   
      reader.onload = (e: ProgressEvent) => {
        const content = (e.target as FileReader).result;
      };
      reader.readAsText(file);
    });

    this.fileToUpload.forEach(file => {
      this.service.AddPhoto(this.idAlbum, file).subscribe(
            (res: any) => {
              this.ngOnInit();
              this.toastr.success('Success', 'Photo added');
            },
            err => {
              console.log(err);
            }
          )
    });
  }
   
  onFilesRejected(files: File[]) {
    console.log(files);
  }
}
