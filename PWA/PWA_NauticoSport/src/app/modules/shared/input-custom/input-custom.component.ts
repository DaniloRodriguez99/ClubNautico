import { Component, ElementRef, Input, OnInit, Output, ViewChild } from '@angular/core';
import { DocumentTypes } from 'src/app/helper/document-types';
import { Genres } from 'src/app/helper/genres';


const INPUT_TYPES = {
  GENRE_SELECT: "genres_select",
  DOCUMENT_TYPE_SELECT: "documentTypes_select",
  TEXT: "text",
  PASSWORD: "password",
  DATE: "date"
}

@Component({
  selector: 'app-input-custom',
  templateUrl: './input-custom.component.html',
  styleUrls: ['./input-custom.component.scss']
})
export class InputCustomComponent implements OnInit {

  constructor() { }

  

  @Input() type:string = INPUT_TYPES.TEXT;
  @Input() label_text:string = ''
  @Input() value:any = ''

  select_default_text: string = ""
  select_items: any[] = [];
  isSelect = false;
  
  ngAfterViewInit() {

  }

  ngOnInit(): void {
    
  }

  

  setValue = (value: any) => {
    this.value = value; //set the value of the input/select whatever
  }

}


