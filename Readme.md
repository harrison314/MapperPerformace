# Mappers performace testing

Project is used for testing the performance of selected mapper. 
The aim is to map the data to the data layer (database) on POCO / DTO objects.

Various methods are used to test the most frequent scenarios in simpler information system.

This project uses the library [Simple Injector](http://simpleinjector.readthedocs.org/en/latest/index.html) as simple IoC container for autodiscover.

Used mappers:

1. Vanila SqlDataReader
1. [Dapper](https://github.com/StackExchange/dapper-dot-net)
1. Entity Framework (v. 6.1.3)
1. Entity Framework, used as Unit of Work
1. Entity framework with [Automapper](http://automapper.org/)
1. [Tiny Mapper](http://tinymapper.net/)

## Testing datbase
 1. MS SQL Server 2014 Express
 1. [ AdventureWorks Sample Database 2014](http://msftdbprodsamples.codeplex.com/)

# Results
<table border="1">
    <thead>
        <tr>
            <th>/</th>
            <th>Load large table</th>
            <th>Pagged result</th>
            <th>Load one row</th>
            <th>Load row with joined collection</th>
            <th>Combined</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Dapper</td>
            <td>174 ms</td>
            <td>54 ms</td>
            <td>3 ms</td>
            <td>12 ms</td>
            <td>30803 ms</td>
        </tr>
        <tr>
            <td>Date Reader</td>
            <td>161 ms</td>
            <td>40 ms</td>
            <td>1 ms</td>
            <td>1 ms</td>
            <td>30054 ms</td>
        </tr>
        <tr>
            <td>Date Reader - closing </td>
            <td>154 ms</td>
            <td>48 ms</td>
            <td>2 ms</td>
            <td>1 ms</td>
            <td>30672 ms</td>
        </tr>
        <tr>
            <td>Entity Framework</td>
            <td>648 ms</td>
            <td>88 ms</td>
            <td>24 ms</td>
            <td>57 ms</td>
            <td>39498 ms</td>
        </tr>
        <tr>
            <td>Entity Framework - AutoMapper </td>
            <td>166 ms</td>
            <td>45 ms</td>
            <td>16 ms</td>
            <td>31 ms</td>
            <td>35705 ms</td>
        </tr>
        <tr>
            <td>Entity Framework - UoF</td>
            <td>126 ms</td>
            <td>44 ms</td>
            <td>6 ms</td>
            <td>3 ms</td>
            <td>34842 ms</td>
        </tr>
        <tr>
            <td>Tiny Mapper</td>
            <td>2011 ms</td>
            <td>83 ms</td>
            <td>5 ms</td>
            <td>18 ms</td>
            <td>674694 ms</td>
        </tr>
    </tbody>
</table>

## License

**The MIT License (MIT)**

Copyright (c) 2016 harrison314

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
