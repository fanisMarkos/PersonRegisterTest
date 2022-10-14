import { Component, OnInit } from '@angular/core';
import { User } from '../Interfaces/UserInterfaces';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  public userTableList: User[] = [];
  public filteredList: User[] = []
  filter: string = "";

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      data => {
        this.userTableList = data;
        this.filteredList = this.userTableList
      })
  }

  filterChange(filter: string) {
    if (filter != "") {
      this.filteredList = this.userTableList.filter(x => x.name?.startsWith(filter))
    }
    else {
      this.filteredList = this.userTableList;

    }
  }

  deleteUser(id: number | undefined): void {
    this.userService.deleteUser(id).subscribe(next => {
      window.location.reload();
    })
  }

}


