import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BlackListService } from 'src/app/shared/blacklist.service';

@Component({
  selector: 'app-black-list',
  templateUrl: './black-list.component.html',
  styleUrls: ['./black-list.component.css']
})
export class BlackListComponent implements OnInit {

  userId: string;
  blackList;
  
  constructor(private activateRoute: ActivatedRoute,
    public service: BlackListService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getBlackList().subscribe(
      res => {
        this.blackList = res;
      }
    )
  }

  onCheckInfo(userId: string) {
    this.router.navigateByUrl('/home/user-profile/' + userId);
  }

  onDeleteFromBlacklist(id: number){
    this.service.DeleteFromBlacklist(id).subscribe(
      (res: any) => {
        this.ngOnInit();
        this.toastr.success('Success!');
      }
    )
  }

}
