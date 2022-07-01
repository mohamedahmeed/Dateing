import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services/services.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private http:ServicesService ) { }
  model:any={};
  logIn:boolean=false;
  ngOnInit(): void {
  }
  login(){
    this.http.logIn(this.model).subscribe(responce=>{
      this.logIn=true;
      console.log(responce);
    },error=>{
      this.logIn=false;
      console.log(error);
    });
    
   
  }
  logout(){
    this.logIn=false;

  }
}
