import { Component, OnInit } from '@angular/core';
import { FriendService } from 'src/app/shared/friend.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(public service : FriendService,
    private toastr: ToastrService) { }

  friendList;

  ngOnInit() {
    this.service.getFriendList().subscribe(
      res => {
        this.friendList = res;
      }
    )
  }

}
