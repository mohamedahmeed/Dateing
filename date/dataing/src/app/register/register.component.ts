import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ServicesService } from '../services/services.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
@Input() Userfromhome:any;
@Output() can =new EventEmitter();
  constructor(private s:ServicesService) { }
model:any={};
  ngOnInit(): void {
  }
register(){
this.s.register(this.model).subscribe(responce=>{
  console.log(responce);
this.Cancel();
},error=>{
  console.log(error);
});

}
Cancel(){
  this.can.emit(false);
  }
}
