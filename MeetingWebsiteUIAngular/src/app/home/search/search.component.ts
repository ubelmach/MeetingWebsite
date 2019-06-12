import { Component, OnInit } from '@angular/core';
import { InfoFromDb } from 'src/app/models/InfoFromDb';
import { SearchService } from 'src/app/shared/search.service';
import { Router } from '@angular/router';
import { ResultSearch } from 'src/app/models/ResultSearch';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  InfoFromDb: InfoFromDb;
  resultSearch: ResultSearch[];

  constructor(public service: SearchService, private router: Router) { }

  ngOnInit() {
    this.service.getInfo().subscribe(
      res => {
        this.InfoFromDb = res as InfoFromDb;
      }
    )
  }

  onSubmit(){
    this.service.searchUsers().subscribe(
      (res : any) => {
        this.resultSearch = res as ResultSearch[];
        console.log('search');
      },
      err =>{
        console.log(err);
      }
    )
  }

}
