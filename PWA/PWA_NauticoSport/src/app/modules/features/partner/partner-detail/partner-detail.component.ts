import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router,  ParamMap } from '@angular/router';
import { PartnerService } from 'src/app/services/partner.service';

@Component({
  selector: 'app-partner-detail',
  templateUrl: './partner-detail.component.html',
  styleUrls: ['./partner-detail.component.scss']
})
export class PartnerDetailComponent implements OnInit {

  userId: any = "";
  private partnerDetails = {};
  constructor( 
    private partenrService : PartnerService,
    private route: ActivatedRoute,
    ) {
       this.route.queryParamMap.subscribe((params) => {
        this.userId = params.get("id");
       });
    }
  

  ngOnInit(): void {
    this.partnerDetails = this.partenrService.getPartnerById(parseInt(this.userId))
  }

  Data: string = "";

  getPartner = () => {
    
  }

}
