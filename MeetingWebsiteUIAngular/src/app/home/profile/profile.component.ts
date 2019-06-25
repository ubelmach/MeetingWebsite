import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { InfoFromDb } from 'src/app/models/InfoFromDb';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styles: ['./profile.css']
})
export class ProfileComponent implements OnInit {

  userDetails;

  InfoFromDb: InfoFromDb;

  visibleDetailsUser = true;
  visiblePhotoUser = true;

  constructor(public service: UserService,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      }
    )

    this.service.getInfo().subscribe(
      res => {
        this.InfoFromDb = res as InfoFromDb;
      }
    )
  }

  imageUrl: string = "/assets/img/add.jpg";
  fileToUpload: File = null;

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

  onChangeImage() {
    this.service.postFile(this.fileToUpload).subscribe(
      (res: any) => {
        console.log('done');
        this.ngOnInit();
        this.onEditPicture();
        this.toastr.success('Update!', 'Edit user infrormation successful.');
      },
      err => {
        console.log(err);
      }
    );
  }

  onEditUser() {
    this.visibleDetailsUser = !this.visibleDetailsUser;
  }

  onEditPicture() {
    this.visiblePhotoUser = !this.visiblePhotoUser;
  }

  onViewAlbums() {
    this.router.navigateByUrl('/home/album');
  }

  onSubmit() {
    this.service.updateUserProfile().subscribe(
      (res: any) => {
        this.toastr.success('Update!', 'Edit user infrormation successful.');
        this.ngOnInit();
        this.onEditUser();
        console.log('update');
      },
      err => {
        if (err.status == 400)
          this.toastr.error('-________-', 'Edit user infrormation failed');
        else
          console.log(err);
      }
    )
  }

  onChangePassword() {
    this.service.change().subscribe(
      (res: any) => {
        this.toastr.success("Password change");
        this.service.changeModel.reset();
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Faild change password');
        else
          console.log(err);
      }
    );
  }
}
