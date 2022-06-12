import { Injectable, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class ServicesService  {

  constructor(private http: HttpClient) { }
    GetUser(){
  return this.http.get("http://localhost:60022/api/Users");
    }
  
}
