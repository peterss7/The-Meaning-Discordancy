import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'normalizeUrl'
})
export class NormalizeUrlPipe implements PipeTransform {

    transform(value: string): string {
        return value.replace(/([^:]\/)\/+/g, '$1');
    }

}