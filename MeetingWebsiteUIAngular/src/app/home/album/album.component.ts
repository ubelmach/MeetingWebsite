import { Component, OnInit } from '@angular/core';
import { AlbumService } from 'src/app/shared/album.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export class AlbumComponent implements OnInit {

  userAlbums;
  photos = [];
  imageUrl: string = "/assets/img/Nophoto.jpg";
  constructor(public service: AlbumService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getAlbums().subscribe(
      res => {
        this.userAlbums = res;
      },
      err => {
        console.log(err);
      }
    );
  }

  onOpenAlbum(id: number){
    this.service.OpenAlbum(id).subscribe(
      (res: any) =>{
        this.photos = res;
        console.log('open')
      },
      err => {
        console.log(err);
      }
    )
  }

  onSubmit() {
    this.service.createAlbum().subscribe(
      (res: any) => {
        this.service.formModel.reset();
        this.ngOnInit();
        this.toastr.success('New album created!')
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Faild created album');
        else
          console.log(err);
      }
    )
}

}
