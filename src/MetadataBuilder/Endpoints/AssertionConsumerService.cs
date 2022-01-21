using MetadataBuilder.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetadataBuilder.Endpoints
{
    public static class AssertionConsumerService
    {
        public static Binding Post => new Binding(Constants.Bindings.Post);
        public static Binding Redirect => new Binding(Constants.Bindings.Redirect);
        public static Binding Artifact => new Binding(Constants.Bindings.Artifact);
    }
}