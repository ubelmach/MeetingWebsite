import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SearchService } from 'src/app/shared/search.service';
import { ToastrService } from 'ngx-toastr';
import { BlackListService } from 'src/app/shared/blacklist.service';
import { SignalRService } from 'src/app/shared/signalR.service';

import * as signalR from "@aspnet/signalr";
import { HttpTransportType } from '@aspnet/signalr';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  userId: string;
  userDetails;

  checkBlacklist: boolean;
  public hubConnection: signalR.HubConnection

  message = '';
  files: File[] = [];

  constructor(private activateRoute: ActivatedRoute,
    public service: SearchService,
    private toastr: ToastrService,
    public blacklist: BlackListService,
    public signalR: SignalRService) { }

  async ngOnInit() {
    
    this.signalR.startConnection();
    
    await this.activateRoute.params.subscribe(params => this.userId = params.id);

    this.service.getSearchUserDetails(this.userId).subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      }
    )

    this.blacklist.CheckBlacklist(this.userId).subscribe(
      res => {
        this.checkBlacklist = res as boolean;
      }
    )
  }

  onAddToFriend() {
    this.service.sendRequestUser(this.userId).subscribe(
      (res: any) => {
        this.toastr.success('Success!', 'User received friend request.');
        console.log('sendrequest');
      },
      (err: any) => {
        if (err.status == 400)
          this.toastr.error('Faild!', 'You have already sent a request to this user.');
        else
          console.log(err);
      }
    )
  }

  onAddToBlacklist() {
    this.blacklist.AddToBlackList(this.userId).subscribe(
      (res: any) => {
        this.toastr.success('Success!', 'User added to blacklist');
        console.log('blacklist');
      },
      (err: any) => {
        if (err.status == 400)
          this.toastr.error('Faild');
        else
          console.log(err);
      }
    )
  }

  onSendMessageFromProfile() {
    this.signalR.SendFromProfile(this.message, this.userId);
  }
}
