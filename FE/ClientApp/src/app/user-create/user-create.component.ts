import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../user-list/user-list.component';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {

  public model :User ={birthDate:new Date(),isActive:true}
  isUpdate :boolean = false;

  constructor(private userService:UserService,private router:Router,private activeRoute:ActivatedRoute) { }

  ngOnInit(): void {
    var id = this.activeRoute.snapshot.params.id
    if(id!=undefined)
    {
      this.userService.getUserByid(id).subscribe(data => {
        this.model=data;
        this.isUpdate = true;
      
      })
    }
    
  }

  onSubmit():void
  {
    if(!this.isUpdate){
   this.userService.createUser(this.model)
   .subscribe(next=> this.router.navigate(['/user-list']));
    }
    else
    {
      this.userService.updateUser(this.model).subscribe(next=>{

        this.router.navigate(['/user-list']);
      })
    }
   
  }
}
