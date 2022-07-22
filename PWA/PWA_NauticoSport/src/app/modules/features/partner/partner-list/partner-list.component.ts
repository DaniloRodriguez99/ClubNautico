import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ContextPanelComponent } from 'src/app/modules/shared/context-panel/context-panel.component';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partner-list.component.html',
  styleUrls: ['./partner-list.component.scss']
})
export class PartnerListComponent implements OnInit {

  constructor(private userService: UserService, private fb: FormBuilder) { }

  ngOnInit(): void {
  }

  browserInput: FormControl = new FormControl('',
  Validators.required,
  );
  users: any[] = [];
  from: number = 0;

  @ViewChild('filterContextPanel')
  filterContextPanel : ContextPanelComponent = new ContextPanelComponent();

  activeFilterModal = (element: HTMLElement) => {
    this.filterContextPanel.activeFilterModal(element);
  }

  seeMore = () => {
    this.userService.getUsers(1, this.from).then((result: any) => {
      this.users = this.users.concat(result.users)
      this.from = this.from + result.users.length
    })
  }

  browse = () => {
    if (this.browserInput.valid) {

    }
  }

}
 