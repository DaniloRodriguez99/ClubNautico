import { Component, OnInit } from '@angular/core';
import { PartnerService } from 'src/app/services/partner.service';

@Component({
  selector: 'app-partner-detail',
  templateUrl: './partner-detail.component.html',
  styleUrls: ['./partner-detail.component.scss']
})
export class PartnerDetailComponent implements OnInit {

  constructor( 
    private partenrService : PartnerService
    ) { }

  ngOnInit(): void {
  }

  Data: string = "";

  getPartner = () => {
    let response = this.partenrService.getPartnerByPartnerId()
    
  }

}
