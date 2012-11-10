//   Copyright 2011 Myles McDonnell (myles.mcdonnell.public@gmail.com)

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//     http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.Collections.Generic;

namespace FileCopy
{
    public static class IoCContainer
    {
        private static readonly IDictionary<Type, object> _instancesByType = new Dictionary<Type, object>();

        public static void Clear ()
        {
            _instancesByType.Clear();
        }

        public static T Resolve<T>()
        {
            return (T)_instancesByType[typeof(T)];
        }

        public static void RegisterInstance(Type contract, object instance)
        {
            _instancesByType.Add(contract, instance);
        }
    }
}
