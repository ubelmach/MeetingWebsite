import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { Info } from 'src/app/models/Info';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  genders: Info[];

  constructor(public service: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getGenders()
    .subscribe((data: Info[]) => this.genders = data);
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.Succeeded) {
          this.service.formModel.reset();
          this.toastr.success('New user created!', 'Registration successful.')
        }
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Email is already taken', 'Registration failed');
        else
          console.log(err);
      }
    )
  }
}
