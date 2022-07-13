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
    let typeSections = this.type.split("_");
    this.isSelect = typeSections[typeSections.length-1] == "select" // set the type name with the "_select" to specify that you will use a select
    if(this.isSelect)
    {
      this.select_default_text = `inputs.${typeSections[0]}.options.default`;
      switch(this.type) // Diferent types of select with diferents options
      {
        case INPUT_TYPES.GENRE_SELECT: 
          this.select_items = this.mapEnum(Genres);
          break;
        case INPUT_TYPES.DOCUMENT_TYPE_SELECT: 
          this.select_items = this.mapEnum(DocumentTypes);
      }
    }
  }

  mapEnum = (Enum: any) => { //Pass a enum
    let mappedItems: any[] = [];
    let typeSections = this.type.split("_"); //Get the type without se aggregations like _select in genres_select, get only "genres"
    Object.keys(Enum).filter((item) => {
      if (isNaN(Number(item))) // filtering the enum list to get only the string without the numbers por example to get "female" , "male" , "other"
      {
        mappedItems.push({text: `inputs.${typeSections[0]}.options.${item}`, value: item}) //Create a path for the idiom resources in en.js / es.js
      }
    })
    return mappedItems;
  }

  setValue = (value: any) => {
    this.value = value; //set the value of the input/select whatever
  }

}


