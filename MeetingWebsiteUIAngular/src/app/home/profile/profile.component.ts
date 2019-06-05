import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../shared/user.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styles: ['./profile.css']
})
export class ProfileComponent implements OnInit {

  userDetails;

  constructor(private router: Router, private service: UserService) { }

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

}
