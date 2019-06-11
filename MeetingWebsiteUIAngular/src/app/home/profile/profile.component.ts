import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { Info } from 'src/app/models/Info';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styles: ['./profile.css']
})
export class ProfileComponent implements OnInit {

  userDetails;
  zodiacSigns;
  genders;

  purposes: Info[];
  languages: Info[];
  badHabits: Info[];
  interests: Info[];

  visibleDetailsUser = true;
  visiblePhotoUser = true;

  constructor(public service: UserService, private toastr: ToastrService, private router: Router) {

  }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      }
    )
    this.service.getZodiacSigns().subscribe(
      res => {
        this.zodiacSigns = res;
      },
      err => {
        console.log(err);
      }
    )
    this.service.getGenders().subscribe(
      res => {
        this.genders = res;
      },
      err => {
        console.log(err);
      }
    )


    this.service.getInfo().subscribe(
      
    )

    this.service.getPurposes()
      .subscribe((data: Info[]) => this.purposes = data);

    this.service.getLanguages()
      .subscribe((data: Info[]) => this.languages = data);

    this.service.getBadHabits()
      .subscribe((data: Info[]) => this.badHabits = data);

    this.service.getInterests()
      .subscribe((data: Info[]) => this.interests = data);
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
        //Image.value = null;
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
}
