import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'csvSpacer'
})
export class CsvSpacerPipe implements PipeTransform {

  transform(values: string[]): string {
    return values.join(', ');
  }
}
