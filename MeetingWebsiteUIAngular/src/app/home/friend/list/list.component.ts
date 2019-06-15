import { Component, OnInit } from '@angular/core';
import { FriendService } from 'src/app/shared/friend.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { BlackListService } from 'src/app/shared/blacklist.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(private activateRoute: ActivatedRoute,
    public service: FriendService,
    private router: Router,
    private toastr: ToastrService,
    public blacklist: BlackListService) { }

  public friendList = null;;
  userId: string;

  async ngOnInit() {
    this.service.getFriendList().subscribe(
      res => {
        this.friendList = res;
      }
    )
    await this.activateRoute.params.subscribe(params => this.userId = params.id);
  }

  onCheckInfo(userId: string) {
    this.router.navigateByUrl('/home/user-profile/' + userId);
  }

  onDelete(friendshipId: number) {
    this.service.DeleteFriend(friendshipId).subscribe(
      async (res: any) => {
        this.ngOnInit();
        this.toastr.success('Success!', 'User moved to "Friend requests"')
      },
      err => {
        console.log(err);
      }
    )
  }

  onAddToBlacklist(friendId: string) {
    this.blacklist.AddToBlackList(friendId).subscribe(
      (res: any) => {
        this.ngOnInit();
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
}
