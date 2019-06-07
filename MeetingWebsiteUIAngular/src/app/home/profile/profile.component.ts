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
  visible = true;

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

  onEditUser() {
    this.visible = !this.visible;
  }

  onSubmit() {
    this.service.updateUserProfile().subscribe(
      (res: any) => {
        if (res.status == 200)  
          this.router.navigate(['/home/profile']);    
        //   this.toastr.success('Update!', 'Edit user infrormation successful.');
        // }
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
