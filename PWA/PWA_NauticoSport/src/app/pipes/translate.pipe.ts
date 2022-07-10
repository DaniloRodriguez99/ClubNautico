import { Pipe, PipeTransform } from '@angular/core';
import { TranslateService } from '../services/translate.service';

@Pipe({
  name: 'translate',
  pure: false
})
export class TranslatePipe implements PipeTransform {

  constructor(private translateService: TranslateService) {
    
  }

  transform(key: string): unknown {
    let sections = key.split(".")
    let value = this.translateService.data || key
    sections.forEach(element => {
      value = value[element];
    });
    if(value == undefined) {
      return key;
    }
    return value;
  }

}
