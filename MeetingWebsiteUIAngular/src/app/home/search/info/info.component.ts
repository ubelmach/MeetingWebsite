import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SearchService } from 'src/app/shared/search.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {

  userId: string;
  userDetails;
  
  constructor(private activateRoute: ActivatedRoute,
    public service:SearchService,
    private router: Router,
    private toastr: ToastrService) { }
  

  async ngOnInit() {
    await this.activateRoute.params.subscribe(params => this.userId = params.id);

    this.service.getSearchUserDetails(this.userId).subscribe(
      res =>{
        this.userDetails = res;
      }
    ),
    err => {
      console.log(err);
    }    
  }

  onAddToFriend(){
    this.service.sendRequestUser(this.userId).subscribe(
      (res: any) => {
        this.toastr.success('Success!', 'User received friend request');
        console.log('sendrequest');
      },
      (err: any ) =>{
        this.toastr.success('Faild!', '-_-');
        console.log(err);
      }
    )
  }
}
