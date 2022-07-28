import { registerLocaleData } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { CustomValidations } from 'src/app/helper/custom-validations';
import { Filter } from 'src/app/helper/filter';
import { RoleEnum } from 'src/app/helper/role-enum';
import { ContextPanelComponent } from 'src/app/modules/shared/context-panel/context-panel.component';
import { PartnerService } from 'src/app/services/partner.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partner-list.component.html',
  styleUrls: ['./partner-list.component.scss']
})
export class PartnerListComponent implements OnInit {

  constructor(
    private partnerService: PartnerService, 
    private fb: FormBuilder,
    private router: Router
    ) { }


  private customValidations : CustomValidations = new CustomValidations();

  ngOnInit(): void {
  }

  browserInput: FormControl = new FormControl('',
    Validators.required,
  );

  formFilters = this.fb.group(
    {
      ciFilterInput: ["", [
        Validators.maxLength(8),
        Validators.minLength(8),
        this.customValidations.numberOnly()
      ]],
      maleFilterInput: [false],
      femaleFilterInput: [false],
      OtherFilterInput: [false],
      dateFromFilterInput: [""],
      dateToFilterInput: [""]
    }, {updateOn: 'change'}
  )


  users: any[] = [];
  from: number = 0;
  pageSize: number = 5;
  isLoading: boolean = false;
  activeSeemore: boolean = false;

  @ViewChild('filterContextPanel')
  filterContextPanel : ContextPanelComponent = new ContextPanelComponent();

  activeFilterModal = (element: HTMLElement) => {
    this.filterContextPanel.activeModal(element);
  }

  browsePartners = () => {
    this.activeSeemore = false;
    this.isLoading = true
    this.users = [];
    this.from = 0;
    this.getUsers();
  }

  seeMore = () => {
    this.isLoading = true
    this.getUsers();
  }

  getUsers = () => {
    this.partnerService.getPartners(this.pageSize, this.from, this.mapFilter()).then((result: any) => {
      this.users = this.users.concat(result.users)
      this.from = this.from + result.users.length
      if(result.users.length < this.pageSize) {
        this.activeSeemore = false;
      } else {
        this.activeSeemore = true;
      }
      this.isLoading = false;
    })
  }

  onFilter = () :any => {
    if(this.formFilters.valid) {
      this.users = [];
      this.from = 0;
      this.browsePartners();
    }
  }

  mapFilter = () :Filter => {
    let result = new Filter();

    if(this.formFilters.valid) {
      result.Ci = parseInt(this.formFilters.value.ciFilterInput);
      result.DateFrom = new Date(this.formFilters.value.dateFromFilterInput);
      result.DateTo = new Date(this.formFilters.value.dateToFilterInput);
      result.Female = this.formFilters.value.femaleFilterInput;
      result.Male = this.formFilters.value.maleFilterInput;
      result.Other = this.formFilters.value.OtherFilterInput;
      result.Role = RoleEnum.partner;
    }

    return result;
  }

  goToDetail = (user: any) => {
    this.router.navigate(['partner/detail'],{ queryParams: { id: user.userId }})
  }
}
 