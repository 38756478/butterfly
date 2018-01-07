# Butterfly
A distributed tracing system and application performance management.

# Design
``` text
+----------------------------------------------------------------------------------+
|  Server                                                                          |
|                                                                                  | 
|  +-----------+   +-----------+   +-----------+   +-----------+   +-----------+   |
|  | Collector +--->    MQ     +--->  Consumer +--->  Storage  +--->   Web UI  |   |  
|  +-----------+   +-----------+   +-----------+   +-----------+   +-----------+   |
|                                                                                  |
+----------------------------------------------------------------------------------+
```
# Quickstart
* download [latest release](https://github.com/ButterflyAPM/butterfly/releases)
* extract `butterfly-server-[latest version]`
* `cd butterfly-server-[latest version]`
* `dotnet butterfly.server.dll`
* browse to [http://localhost:9618](http://localhost:9618) to find traces

# Screenshots
### Find-traces View
![](docs/images/find-traces.png)
### Trace Detail View
![](docs/images/trace.png)
### Service dependencies View
![](docs/images/dependency.png)
# Related Repositories
### Instrumentation Libraries
* [.NET Core Client](https://github.com/ButterflyAPM/butterfly-csharp)
### Components
* [Web UI](https://github.com/ButterflyAPM/butterfly-ui)

# Contribute
One of the easiest ways to contribute is to participate in discussions and discuss [issues](https://github.com/ButterflyAPM/butterfly/issues). You can also contribute by submitting pull requests with code changes.

# License
[MIT](https://github.com/ButterflyAPM/butterfly/blob/master/LICENSE)
