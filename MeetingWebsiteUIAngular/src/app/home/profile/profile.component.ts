import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../shared/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styles: ['./profile.css']
})
export class ProfileComponent implements OnInit {

  userDetails;
  visibleDetailsUser = true;
  visiblePhotoUser = true;

  constructor(public service: UserService, private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      }
    )
  }

  imageUrl: string = "/assets/img/add.jpg";
  fileToUpload: File = null;

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    var reader = new FileReader();
    reader.onload = (event:any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

  onChangeImage(Image){
    this.service.postFile(this.fileToUpload).subscribe(
      (res: any ) => {
        console.log('done');
        Image.value = null;
        this.router.navigateByUrl('/home/profile');
        this.toastr.success('Update!', 'Edit user infrormation successful.');
      },
      err =>{
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

  onSubmit() {
    this.service.updateUserProfile().subscribe(
      (res: any) => {
          this.toastr.success('Update!', 'Edit user infrormation successful.');
          this.router.navigateByUrl('/home/profile');
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
}
