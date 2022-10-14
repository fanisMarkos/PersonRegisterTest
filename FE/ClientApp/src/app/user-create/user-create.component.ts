import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { type } from 'os';
import { UserCreateEdit, UserTitle, UserType } from '../Interfaces/UserInterfaces';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {

  public model: UserCreateEdit = { birthDate: new Date(), isActive: true }
  public titles: UserTitle[] = [];
  public types: UserType[] = [];
  code?: string
  isUpdate: boolean = false;

  constructor(private userService: UserService, private router: Router, private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {

    this.userService.getUserTitles().subscribe(data => this.titles = data)
    this.userService.getUserTypes().subscribe(data => this.types = data);
    var id = this.activeRoute.snapshot.params.id
    if (id != undefined) {
      this.userService.getUserByid(id).subscribe(data => {
        this.model = data;
        this.isUpdate = true;
        this.code = this.types.find(x => x.id == this.model.userTypeId)?.code

      })
    }

  }

  onSubmit(): void {
    if (!this.isUpdate) {
      this.userService.createUser(this.model)
        .subscribe(next => this.router.navigate(['/user-list']));
    }
    else {
      this.userService.updateUser(this.model).subscribe(next => {

        this.router.navigate(['/user-list']);
      })
    }

  }

  typeChanged(id: any): void {
    this.code = this.types.find(x => x.id == this.model.userTypeId)?.code;
  }
}
