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
