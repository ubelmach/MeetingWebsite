import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumService } from 'src/app/shared/album.service';

@Component({
  selector: 'app-user-profile-album',
  templateUrl: './user-profile-album.component.html',
  styleUrls: ['./user-profile-album.component.css']
})
export class UserProfileAlbumComponent implements OnInit {

  constructor(public activateRoute: ActivatedRoute,
    public service: AlbumService,
    private router: Router) { }

  userId: string;
  albums;
  imageUrl: string = "/assets/img/cameras-clipart-pdf-1.png";

  async ngOnInit() {
    await this.activateRoute.params.subscribe(
      params => this.userId = params.id
    );
    this.service.getAlbumsUser(this.userId).subscribe(
      (res: any) => {
        this.albums = res;
      }
    )
  }

  onOpenAlbum(id: number) {
    this.router.navigateByUrl('/home/user-profile-album/' + this.userId + '/user-profile-details-album/' + id.toString());
  }

  onGoHome() {
    this.router.navigateByUrl('/home/user-profile-album/' + this.userId)
  }

}
